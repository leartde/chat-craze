import  {useEffect, useState} from "react";
import {Post} from "@/Pages/Posts/PostGrid.tsx";
import FetchPosts from "@/Services/PostServices/FetchPosts.ts";
import PostCard from "@/Components/Posts/PostCard.tsx";
import {useDispatch, useSelector} from "react-redux";
import {RootState} from "@/State/Store.ts";
import PostPagination from "@/Components/Posts/PostPagination.tsx";
import {setHasNext, setHasPrevious, setTotalPages} from "@/State/PostParameters/PostParametersSlice.ts";

type UserPostsProps = {
    username : string;
}
const UserPosts = ({username}:UserPostsProps) => {
    const dispatch = useDispatch();
    const [posts, setPosts] = useState<Post[]>([]);
    const pageSize : number  = 6;
    const pageNumber : number = useSelector((state: RootState) => state.postParameters.pageNumber);

    useEffect(() => {
        const getPosts = async () => {
            const data = await FetchPosts({
                pageSize: pageSize, pageNumber: pageNumber, author:username });
            if(data){
                setPosts(data.data);
                dispatch(setTotalPages(data.totalPages));
                dispatch(setHasPrevious(data.hasPrevious));
                dispatch(setHasNext(data.hasNext));
            }
        };
         getPosts();
    }, [dispatch, username, pageNumber, pageSize]);
    return (
        <div className="w-1/2 mx-auto mt-12 p-6 border-4 border-primary max-md:w-4/5">
            <div className="flex flex-wrap gap-8 sm:justify-center w-full  gap-y-12">
                {
                    posts.map((post) => (
                        <PostCard
                            id={post.id}
                            key={post.id}
                            title={post.title}
                            userName={post.userName}
                            content={post.content}
                            likeCount={post.likeCount}
                            imageUrl={post.imageUrl}
                            createdAt={post.createdAt}
                        />
                    ))
                }


            </div>
            <PostPagination/>
        </div>
    );
};

export default UserPosts;

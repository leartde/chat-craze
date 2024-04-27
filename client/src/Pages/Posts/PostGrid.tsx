import  {useEffect, useState} from 'react';
import PostCard2 from "@/Components/Posts/PostCard2.tsx";
import CategorySelector from "@/Components/Posts/CategorySelector.tsx";
import {useDispatch, useSelector} from "react-redux";
import {RootState} from "@/State/Store.ts";
import fetchPosts from "@/Services/PostServices/FetchPosts.ts";
import SearchTerm from "@/Components/Posts/SearchTerm.tsx";
import {setTotalPages} from "@/State/PostParameters/PostParametersSlice.ts";
import PostPagination from "@/Components/Posts/PostPagination.tsx";
import PostParameters from "@/Components/Posts/PostParameters.tsx";
export type Post = {
    id: number;
    title: string;
    userName: string;
    content: string;
    likeCount: number;
    imageUrl: string;
    createdAt: Date;
}
const PostGrid = () => {
    const [posts, setPosts] = useState<Post[]>([]);
    const category : string = useSelector((state: RootState) => state.postParameters.category);
    const searchTerm : string = useSelector((state: RootState) => state.postParameters.searchTerm);
    const pageSize : number  = 9;
    const pageNumber : number = useSelector((state: RootState) => state.postParameters.pageNumber);
    const author : string = useSelector((state: RootState) => state.postParameters.author);
    const orderBy : string = useSelector((state: RootState) => state.postParameters.orderBy);
    console.log("Current page number: ", pageNumber);
    const dispatch = useDispatch();

    useEffect(() => {
        const getData = async() => {
           const posts = await fetchPosts({
               category: category,
               pageSize : pageSize,
               pageNumber : pageNumber,
               searchTerm: searchTerm,
               author: author,
               orderBy : orderBy
           });
           if(posts){
               setPosts(posts.data);
               dispatch(setTotalPages(posts.totalPages));
           }
        }
        getData();

    },[category, searchTerm, author, pageSize, pageNumber, orderBy]);
    console.log("search term ", useSelector((state: RootState) => state.postParameters.searchTerm))
    return (
        <div className="w-full bg-gray-800">
            <div className="flex gap-12 h-full px-4 ml-8 mt-24">
                <PostParameters/>
                <div className=" relative grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 w-full  gap-y-12">
                    {
                        posts.map((post) => (
                            <PostCard2
                                key={post.id}
                                title={post.title}
                                userName={post.userName}
                                imageUrl={post.imageUrl}
                                content={post.content}
                                createdAt={post.createdAt}
                                likeCount={post.likeCount}
                            />

                        ))
                    }
                </div>
            </div>
            <PostPagination/>
        </div>
    );
};

export default PostGrid;


import {Post} from "@/Pages/Posts/PostGrid.tsx";
import SinglePostCard from "@/Components/Posts/SinglePostCard.tsx";
import {useLoaderData} from "react-router-dom";
import CommentSection from "@/Components/Posts/CommentSection.tsx";
import SimilarPostsBar from "@/Components/Posts/SimilarPostsBar.tsx";



const SinglePost = () => {
    let post: Post = useLoaderData();
    return (
        <div className="flex w-full p-8  bg-gray-900 border border-black">
            <div className="flex w-3/4 flex-col gap-4">
                <SinglePostCard likeCount={post.likeCount} id={post.id} imageUrl={post.imageUrl}
                                category={post.category}
                                createdAt={post.createdAt} title={post.title}
                                content={post.content} userName={post.userName} />
                <CommentSection postId={post.id} />

            </div>
            <div>
                <SimilarPostsBar id={post.id} category={post.category}/>
            </div>


            
        </div>
    );
};

export default SinglePost;

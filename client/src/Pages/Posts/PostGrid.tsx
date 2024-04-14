import React, {useEffect, useState} from 'react';
import PostCard from "@/Components/Posts/PostCard.tsx";
import PostCard2 from "@/Components/Posts/PostCard2.tsx";
import CategorySelector from "@/Components/Posts/CategorySelector.tsx";
interface Post{
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
    useEffect(() => {
        const fetchPosts = async() => {
            try{
                const response = await fetch("http://localhost:5002/api/posts?PageSize=1000");
                const data = await response.json();
                setPosts(data);
            }
            catch (e) {
                console.log("Error fetching posts: ", e);
            }
        }
        fetchPosts();
    },[]);
    return (
        <div className="flex flex-col px-4 ml-8 mt-24">
            <CategorySelector/>
            <div className="top-16 relative grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 w-full  gap-y-12">
                {
                    posts.map((post) => (
                        <PostCard2
                            key={post.id}
                            title={post.title}
                            userName={post.userName}
                            imageUrl={post.imageUrl}
                            content={post.content}
                            createdAt={post.createdAt}
                        />

                    ))
                }
            </div>
        </div>
    );
};

export default PostGrid;

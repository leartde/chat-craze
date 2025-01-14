import  {useEffect, useState} from 'react';
import {Post} from "@/Pages/Posts/PostGrid.tsx";
import fetchPosts from "@/Services/PostServices/FetchPosts.ts";
import {useNavigate} from "react-router-dom";
type SimilarPostsProps = {
    category: string;
    id: number;

}

const SimilarPostsBar = ({category, id}: SimilarPostsProps) => {
    const [posts, setPosts] = useState<Post[]>([]);
    const navigate = useNavigate();
    useEffect(() => {
        const getData = async() => {
            const posts = await fetchPosts({
                category: category,
                pageSize : 3,
                pageNumber : 1
            });
            if (posts) {
                const filteredPosts = posts.data.filter((post: Post) => post.id != id);
                setPosts(filteredPosts);
            }
        }
        getData();
    }, [category, id]);
    return (
        <div className=" w-full  lg:block hidden border border-secondary py-2 px-2">
            <div className="flex py-6 w-[420px] flex-col gap-4 text-secondary px-3">
                <h1 className="text-2xl  font-semibold">Similar Posts</h1>
                {
                    posts.map((post) => (
                        <div onClick={()=>navigate(`/posts/${post.id}`)} key={post.id} className="flex gap-4 cursor-pointer shadow-md shadow-gray-400    border-2 border-secondary rounded-xl">
                            <img src={post.imageUrl} className="w-20 h-20  rounded-xl" alt=""/>
                            <div>
                                <h1 className="text-lg font-semibold">{post.title}</h1>
                                <p className="text-sm text-gray-300">{post.userName}</p>
                            </div>
                        </div>
                    ))
                }
            </div>

        </div>
    );
};

export default SimilarPostsBar;

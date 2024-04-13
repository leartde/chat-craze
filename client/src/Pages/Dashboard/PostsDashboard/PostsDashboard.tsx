import {useEffect, useState} from 'react';
import {DataTable} from "@/Pages/Dashboard/PostsDashboard/Data-table.tsx";
import {columns} from "@/Pages/Dashboard/PostsDashboard/Columns.tsx";
type Post = {
    id: number;
    title: string;
    userName: string;
    likeCount: number;
}
const PostsDashboard = () => {
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
    }, []);
    return (
        <div>
            <div className="container mx-auto py-10">
                <DataTable columns={columns} data={posts}/>
            </div>
        </div>
    );
};

export default PostsDashboard;

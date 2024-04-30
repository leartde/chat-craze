import {Post} from "@/Pages/Posts/PostGrid.tsx";

const FetchPost = async (id: number) => {
    try {
        const response = await fetch(`http://localhost:5002/api/posts/${id}`);
        const data : Post = await response.json();
        return data;
    } catch (e) {
        console.log("Error fetching post: ", e);
    }

}

export default FetchPost;
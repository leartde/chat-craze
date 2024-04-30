import axios from "axios";
import FetchComments from "@/Services/CommentServices/FetchComments.ts";

type CommentProps = {
    postId: number;
    content: string;
    userId: string;
}
const PostComment = async ({postId, content, userId} : CommentProps) =>

{
    const url = `http://localhost:5002/api/posts/${postId}/comments`;
    const formData = {
        content: content,
        userId: userId
    }
    try{
        const response = await axios.post(url, formData);
        if (response.status === 200){
            return response.data;
            await FetchComments(postId);
        }
        else{
            console.log("Error posting comment");
            return;
        }
    }
    catch (e){
        console.log("Error posting comment");
        return;
    }
}

export default PostComment;
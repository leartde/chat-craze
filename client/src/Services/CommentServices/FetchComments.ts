import axios from "axios";

const FetchComments = async (postId: number ) => {
    const url = `http://localhost:5002/api/posts/${postId}/comments`;
    try{
        const response = await axios.get(url);
        if (response.status === 200){
            return response.data;
        }
        else{

            console.log("Error fetching comments");
            return;
        }
    }
    catch (e){
        console.log("Error fetching comments");
        return;
    }
}

export default FetchComments;
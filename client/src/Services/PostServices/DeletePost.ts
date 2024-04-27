import axios from "axios";

const DeletePost = async (id: number) => {
   try {
            const response = await axios.delete(`http://localhost:5002/api/posts/${id}`,);
            if(response.status == 200){
                console.log('Post deleted successfully');
                return;
            }
            console.log('Error deleting post: ', response);
        } catch (e) {
            console.log('Error deleting post: ', e);
            return;
        }
};

export default DeletePost;

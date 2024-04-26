const DeletePost = async (id: number) => {
   try {
            const response = await fetch(`http://localhost:5002/api/posts/${id}`, {
                method: 'DELETE',
            });
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

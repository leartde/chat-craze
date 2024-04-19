
const DeleteUser = async (id: string) => {
    try {
        const response = await fetch(`http://localhost:5002/api/users/${id}`, {
            method: 'DELETE',
        });
        if(response.status == 200){
            console.log('User deleted successfully');
            return;
        }
        console.log('Error deleting user: ', response);
    } catch (e) {
        console.log('Error deleting user: ', e);
        return;
    }
};

export default DeleteUser;

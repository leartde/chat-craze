import {toast} from "react-toastify";

const DeleteUser = async (id: string) => {
    try {
        const response = await fetch(`http://localhost:5002/api/users/${id}`, {
            method: 'DELETE',
        });
        if(response.status == 200){
            console.log('User deleted successfully');
            toast.success("User deleted successfully")
            return;
        }
        console.log('Error deleting user: ', response);
        toast.error("Failed deleting user")
    } catch (e) {
        console.log('Error deleting user: ', e);
        toast.error("Failed deleting user");
        return;
    }
};

export default DeleteUser;

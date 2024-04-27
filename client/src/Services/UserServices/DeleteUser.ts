import {toast} from "react-toastify";
import axios from "axios";
const DeleteUser = async (id: string) => {
    try {
        const response = await axios.delete(`http://localhost:5002/api/users/${id}`);
        if(response.status == 200){
            console.log('User deleted successfully');
            toast.success("User deleted successfully");
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

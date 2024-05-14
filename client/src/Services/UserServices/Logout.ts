import axios from "axios";

const Logout = async () => {

    const url = `http://localhost:5002/api/users/authentication/logout`;

    try{
        const res = await axios.post(url,{}, { withCredentials: true });
        if (res.status === 200) {
            console.log("User logged out successfully");
        }
    }
    catch (e) {
        console.log(e);
    }

};

export default Logout;

import axios from "axios";

export type User ={
    id: string;
    userName: string;
    email: string;
    role: string;
    avatarUrl : string
}
export const FetchUsers = async () => {
    try{
        const response = await axios.get("http://localhost:5002/api/users");
        if(response.status == 200){
            return  response.data;
        }
        else {
            console.log('Error fetching users: ', response);
            return;
        }
    }
    catch(e){
        console.log(e);
    }
}
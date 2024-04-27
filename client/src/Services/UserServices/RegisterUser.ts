import axios from "axios";

type RegisterProps = {
    userName : string,
    email : string,
    password : string
}

export type ApiResponse = {
    data : string,
    status : number;
}


const RegisterUser = async({userName, email, password} : RegisterProps) : Promise<ApiResponse> => {
    const formData : RegisterProps ={
        userName : userName,
        email : email,
        password : password
    }
    try{

        const response : ApiResponse = await axios.post("http://localhost:5002/api/users/authentication/register",
            formData
            );
        console.log(response);
           return response;
        }
        catch (e){
            console.log(e);
            return {
                data: "Error logging in",
                status: 400
            };
        }
    }



export default RegisterUser;

import axios from "axios";
import { jwtDecode } from "jwt-decode";


type LoginProps = {
    UserName : string;
    Password : string;
}
type ApiResponse = {
    data :{
        accessToken: string;
        refreshToken: string;
    };
    status: number;
}

export type UserClaims = {
    username: string,
    email: string,
    id: string,
    avatarUrl: string,
    role: string
}

const Login = async ({UserName, Password}: LoginProps) => {
    const FormData: LoginProps = {
        UserName: UserName,
        Password: Password,
    };

    // const userClaimsState = useSelector((state: RootState) => state.userClaims);


   try{
       const response : ApiResponse = await axios.post(`http://localhost:5002/api/users/authentication/login`,
           FormData
       )
       console.log("response", response);
       if(response.status == 200){
           const { accessToken, refreshToken } = response.data;
           // const decodedToken = jwtDecode(accessToken) as { [key: string]: string };
           // const userClaims : UserClaims = {
           //     username: decodedToken.username,
           //     email: decodedToken.email,
           //     id: decodedToken.id,
           //     avatarUrl: decodedToken.avatarUrl,
           //     role: decodedToken.role
           // };
           const decodedToken = jwtDecode(accessToken) as UserClaims;
           localStorage.setItem("accessToken", accessToken);
           localStorage.setItem("refreshToken", refreshToken);



           return {
               success : true,
               claims : decodedToken
           }
       }
       else {
           console.log('Error logging in: ', response);
           return false;
       }
   }
   catch (e){
         console.log('Error logging in: ', e);
         return;
   }

};

export default Login;

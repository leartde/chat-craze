import axios from "axios";

export type RefreshTokenProps = {
    accessToken: string;
    refreshToken: string;
}
const RefreshToken = async ({accessToken, refreshToken}: RefreshTokenProps) => {

    const FormData = {
        accessToken: accessToken,
        refreshToken: refreshToken
    };
    try{
        const response = await axios.post(`http://localhost:5002/api/users/authentication/refresh`, FormData);
        if(response.status == 200){
            const { accessToken, refreshToken } = response.data;
            localStorage.setItem("accessToken", accessToken);
            localStorage.setItem("refreshToken", refreshToken);
            return accessToken;

        }
        else {
            console.log('Error refreshing token: ', response);
            return false;
        }
    }
    catch (e){
        console.log('Error refreshing token: ', e);
        return;
    }
}

export default RefreshToken;
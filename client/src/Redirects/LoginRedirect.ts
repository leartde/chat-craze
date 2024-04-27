import {useNavigate} from "react-router-dom";
import {useEffect} from "react";

export const LoginRedirect = () => {
    const navigate = useNavigate();
    useEffect(() => {
        navigate("/authentication");
    }, [navigate]);
    return null;
}
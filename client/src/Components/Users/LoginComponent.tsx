import React, {useEffect, useState} from 'react';
import {Label} from "@/Components/ui/label.tsx";
import {Input} from "@/Components/ui/input.tsx";
import {Button} from "@/Components/ui/button.tsx";
import Login, {UserClaims} from "@/Services/UserServices/Login.ts";
import {ToastContainer} from "react-toastify";
import {useNavigate} from "react-router-dom";
import {useDispatch} from "react-redux";
import {setUserClaims} from "@/State/UserClaims/UserClaimsSlice.ts";
import initializeApp from "@/Services/UserServices/InitializeApp.ts";
import {jwtDecode} from "jwt-decode";

const LoginComponent = () => {
    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [error, setError] = useState<boolean>(false);
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const handleUsernameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(e.target.value);
    }
    const handlePasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(e.target.value);
    }
    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const loggedIn = await Login({UserName: username, Password: password});
        if (loggedIn && loggedIn.success){
            navigate("/");
            dispatch(setUserClaims(loggedIn.claims));
        }
        else {
            setError(true);
        }

    }

    useEffect(() => {
        const accessToken  = localStorage.getItem("accessToken");
        const decodedToken = jwtDecode(accessToken) as UserClaims;
        initializeApp();
        dispatch(setUserClaims(decodedToken));
    }, [dispatch]);
    return (
        <div >
            <ToastContainer/>
            <form onSubmit={handleSubmit} className="my-4 space-y-2" method="post">
                <Label>Username</Label>
                <Input value={username} onChange={handleUsernameChange} id="username"></Input>
                <Label>Password</Label>
                <Input value={password} onChange={handlePasswordChange} id="password"></Input>
                <Button className="text-secondary"   type="submit">Login</Button>
                <p className={` ${error?"":"hidden"} text-red-600 font-semibold`}>Username or password is incorrect. </p>
            </form>
        </div>
    );
};

export default LoginComponent;

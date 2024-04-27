import React, {useState} from 'react';
import RegisterUser, {ApiResponse} from "@/Services/UserServices/RegisterUser.ts";
import {Label} from "@/Components/ui/label.tsx";
import {Input} from "@/Components/ui/input.tsx";
import {Button} from "@/Components/ui/button.tsx";

const RegisterComponent = () => {
    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [email, setEmail] = useState<string>("");
    const [response, setResponse] = useState<string>("");
    const handleUsernameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(e.target.value);
    }
    const handlePasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(e.target.value);
    }
    const handleEmailChange = (e : React.ChangeEvent<HTMLInputElement>) =>{
        setEmail(e.target.value);
    }

    const handleSubmit = async (e: React.ChangeEvent<HTMLInputElement>) =>{
        e.preventDefault();
        const registered : ApiResponse   =  await RegisterUser({userName : username, email : email, password: password});
        if(registered.status === 200){
            setResponse("You have been successfully registered. Please continue logging in ");
        }
        else{
            setResponse("One or more validation errors occurred.");
        }


    }
    return (
        <div>
            <form onSubmit={handleSubmit} className="my-4 space-y-2" method="post">
                <Label> Email </Label>
                <Input id="email" value={email} onChange={handleEmailChange}></Input>
                <Label> Username </Label>
                <Input id="username" value={username} onChange={handleUsernameChange}></Input>
                <Label> Password</Label>
                <Input id="password" value={password} onChange={handlePasswordChange} type={password}></Input>
                <Button type="submit">Register</Button>
                <p className={`${response.startsWith('Y')?'text-green-600':'text-red-600'}`}> {response}</p>

            </form>
        </div>
    );
};

export default RegisterComponent;

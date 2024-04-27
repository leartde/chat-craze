import {Tabs, TabsContent} from '@/Components/ui/tabs.tsx';
import {TabsList, TabsTrigger} from "@/Components/ui/tabs.tsx";
import LoginComponent from "@/Components/Users/LoginComponent.tsx";
import {useState} from "react";
import RegisterComponent from "@/Components/Users/RegisterComponent.tsx";

const AuthenticationComponent = () => {
    return (
        <div className="h-[480px]">
            <Tabs defaultValue="login" className="rounded-xl p-6  w-[400px] h-full bg-white flex flex-col items-center">
                <TabsList>
                    <TabsTrigger value="login">Login</TabsTrigger>
                    <TabsTrigger value="register">Register</TabsTrigger>
                </TabsList>
                <TabsContent value="login">
                    <LoginComponent/>
                </TabsContent>
                <TabsContent value="register">
                    <RegisterComponent/>
                </TabsContent>
            </Tabs>
        </div>
    );
};

export default AuthenticationComponent;

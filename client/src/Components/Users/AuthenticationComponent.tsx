import {Tabs, TabsContent} from '@/Components/ui/tabs.tsx';
import {TabsList, TabsTrigger} from "@/Components/ui/tabs.tsx";
import LoginComponent from "@/Components/Users/LoginComponent.tsx";
import {useState} from "react";
import RegisterComponent from "@/Components/Users/RegisterComponent.tsx";

const AuthenticationComponent = () => {
    const [activeTab, setActiveTab] = useState<string>("login");
    console.log(activeTab);
    return (
        <div className="h-[480px] ">
            <Tabs defaultValue="login" className="rounded-xl p-6  w-[400px] h-full bg-white flex flex-col items-center">
                <TabsList className="border border-black rounded-xl">
                    <TabsTrigger
                        onClick={() => setActiveTab("login")}
                        className={`${activeTab === "login" ? "!bg-primary" : ""} rounded-xl !w-full !h-full border-r border-black`}
                        value="login"
                    >
                        Login
                    </TabsTrigger>
                    <TabsTrigger
                        onClick={() => setActiveTab("register")}
                        className={`${activeTab === "register" ? "!bg-primary" : ""} border-l border-black`}
                        value="register"
                    >
                        Register
                    </TabsTrigger>
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

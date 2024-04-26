import { useNavigate } from "react-router-dom";
import { Button } from "@/Components/ui/button.tsx";
import {useState} from "react";

const DashboardSidebar = () => {
    const navigate = useNavigate();
    const [activeLink, setActiveLink] = useState<string>("Users");

    const handleButtonClick = (link: string) => {

        setActiveLink(link);
        if(link == "Users")
            navigate('');
        else {
            navigate("posts")
        }

    };

    return (
        <div className="w-32 mt-16 ml-12 flex flex-col gap-4">
            <Button
                variant={activeLink.toLowerCase() === 'users' ? "secondary" : "default"}
                className="font-normal text-lg !rounded-xl"
                onClick={() => handleButtonClick('Users')}
            >
                Users
            </Button>
            <Button
                variant={activeLink.toLowerCase() === 'posts' ? "secondary" : "default"}
                className="font-normal text-lg !rounded-xl"
                onClick={() => handleButtonClick('Posts')}
            >
                Posts
            </Button>
        </div>
    );
};

export default DashboardSidebar;

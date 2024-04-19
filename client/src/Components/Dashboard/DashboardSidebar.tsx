import {FaUsersCog} from "react-icons/fa";
import {BsFileEarmarkPost} from "react-icons/bs";
import { FaComment } from "react-icons/fa";
import {BiCategory} from "react-icons/bi";
import {useState} from "react";
import {useNavigate} from "react-router-dom";
interface Icon {
    name: string;
    element: JSX.Element;
    link: string
}

const Icons: Icon[] = [
    {
        name: "Users",
        element: <FaUsersCog/>,
        link: "/dashboard",
    },
    {
        name: "Posts",
        element: <BsFileEarmarkPost />,
        link : "posts"
    },
    // {
    //     name: "Comments",
    //     element: <FaComment />,
    //     link : "dashboard/comments"
    // },
    // {
    //     name: "Categories",
    //     element: <BiCategory/>,
    //     link : "dashboard/categories"
    // },
];
const DashboardSidebar = () => {
    const navigate = useNavigate();
    const [active, setActive] = useState<string>(window.location.href=="http://localhost:5173/dashboard"?"Users":"Posts");
    return (
        <div className="flex flex-col border border-gray-800 mt-24 bg-white  w-[12%] h-24 ">
            <ul className="text-center text-xl font-normal  text-black h-full ">
                {Icons.map((icon, index) => {
                    return (
                        <li key={index}
                             onClick={() => {
                                 setActive(icon.name);
                                    navigate(icon.link);
                             }}
                            className={`${active==icon.name?`bg-gray-300`:''} items-center h-1/2 flex gap-4  px-4 py-2 border border-t-gray-800 hover:bg-gray-100 cursor-pointer`}>
                            {icon.element} {icon.name}
                        </li>
                    );
                })}
            </ul>

        </div>
    );
};

export default DashboardSidebar;
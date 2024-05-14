import {User} from "@/Services/UserServices/FetchUsers.ts";
import {FaEdit, FaUserFriends} from "react-icons/fa";
import {FaMessage} from "react-icons/fa6";

const ProfileCard = ({userName, avatarUrl, email} : User) => {
    return (
        <div className="flex flex-wrap p-8 m-2 bg-primary w-1/2 mx-auto max-md:w-4/5">
            <div className="h-32 w-32">
                <img alt="avatar" className="rounded-xl w-full h-full" src={avatarUrl}/>
            </div>

            <div className="flex flex-col p-4 gap-2">
                <h2 className="text-2xl text-secondary text-wrap max-md:text-left font-semibold">{userName}</h2>
                <h3 className="text-xl text-secondary font-normal">{email}</h3>
            </div>

            <div className="flex flex-col p-2 gap-4">
                <button className="bg-blue-400 text-secondary p-2 rounded-xl"> <FaUserFriends className="h-8 w-8"/> </button>
                <button className="bg-green-400  text-secondary p-2 rounded-xl"> <FaMessage className="h-8 w-8"/></button>
            </div>
            <div className="ml-4 flex p-2 items-start ">
<button className="bg-yellow-400 text-secondary h-12 p-2 rounded-xl"><FaEdit className="h-8 w-8"/></button>
            </div>
        </div>
    );
};

export default ProfileCard;

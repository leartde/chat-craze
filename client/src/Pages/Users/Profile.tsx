import React from 'react';
import ProfileCard from "@/Components/Users/ProfileCard.tsx";
import {User} from "@/Services/UserServices/FetchUsers.ts";
import {useLoaderData} from "react-router-dom";
import UserPosts from "@/Components/Users/UserPosts.tsx";

const Profile = () => {
    const user : User = useLoaderData();
    return (
        <div className="w-full flex flex-col p-8 m-0">
            <ProfileCard id={user.id} avatarUrl={user.avatarUrl}
               role={user.role} userName={user.userName} email={user.email}/>
            <UserPosts username={user.userName}/>
        </div>
    );
};

export default Profile;

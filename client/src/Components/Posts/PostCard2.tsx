import React from 'react';
import {SlLike} from "react-icons/sl";
type PostProps = {
    title: string;
    userName: string;
    content: string;
    imageUrl: string;
    createdAt : Date;
    likeCount : number;
}
const PostCard2 = ({title, userName, content, imageUrl, createdAt, likeCount} : PostProps) => {
    const dateObject = new Date(createdAt);
    const formattedDate = `${dateObject.getDate()}/${dateObject.getMonth() + 1}/${dateObject.getFullYear()} ${dateObject.getHours()}:${dateObject.getMinutes()}`;

    return (
        <div className="cursor-pointer bg-primary rounded-xl flex items-center space-y-6  flex-col w-96 h-96 shadow-xl ">
            <div className="bg-cover h-[50%] w-full " style={{
                backgroundImage: `url(${imageUrl})`,
            }}>

            </div>
            <div className="w-full pl-4 ">
                <h1 className="text-2xl font-bold text-secondary font-Montserrat">{title}
                    <span className="text-xl font-semibold"> by {userName}</span>
                </h1>
                <p className="text-sm text-secondary">{content.length > 250 ? `${content.substring(0, 250)}...` : content}</p>

                <div className="mt-12 flex justify-between">
                    <div className="flex flex-row gap-1 items-center"><p className="inline text-md font-normal">{likeCount}</p> <SlLike className="text-sm"/></div>
                    <p className="text-sm ">{formattedDate} </p>
                </div>
            </div>


        </div>
    );
};

export default PostCard2;

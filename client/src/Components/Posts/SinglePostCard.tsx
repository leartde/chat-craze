import React from 'react';
import {Post} from "@/Pages/Posts/PostGrid.tsx";
import {SlLike} from "react-icons/sl";
import {FaComment} from "react-icons/fa";
import {useNavigate} from "react-router-dom";


const SinglePostCard = ({ title, imageUrl, content, userName, likeCount, createdAt} : Post) => {
    const date : string = new Date(createdAt).toLocaleDateString();
    return (
        <div  className="bg-primary text-secondary  lg:w-3/4 w-full ml-12 rounded-xl  ">
            <div className=" mt-4 w-full  h-96  drop-shadow-lg shadow-2xl">
                <img src={imageUrl} className="rounded-xl w-full h-full" alt=""/>
            </div>
            <div className="lg:px-8 px-2 flex flex-col gap-6 ">
                <h1 className="text-4xl font-semibold  max-md:text-2xl max-md:text-left">{title}
                    <span className="text-2xl font-normal"> {userName} </span>
                </h1>
                <p className=" text-lg">{content}{content}{content}</p>
                <div className="flex   text-xl justify-between py-2 ">
                    <div className="flex gap-4 items-center">
                        <div className="flex items-center gap-2">
                            {likeCount}
                            <SlLike className="cursor-pointer "/>
                        </div>
                        <FaComment className="cursor-pointer"/>
                    </div>
                    <div className="">
                        <p className="text-lg">{date}</p>

                    </div>
                </div>


            </div>


        </div>
    );
};

export default SinglePostCard;

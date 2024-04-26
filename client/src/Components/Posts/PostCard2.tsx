import React from 'react';
type PostProps = {
    title: string;
    userName: string;
    content: string;
    imageUrl: string;
    createdAt : Date
}
const PostCard2 = ({title, userName, content, imageUrl, createdAt} : PostProps) => {
    const dateObject = new Date(createdAt);
    const formattedDate = `${dateObject.getDate()}/${dateObject.getMonth() + 1}/${dateObject.getFullYear()} ${dateObject.getHours()}:${dateObject.getMinutes()}`;

    return (
        <div className=" flex items-center space-y-6  flex-col w-96 h-96 shadow-xl ">
            <div className="bg-cover h-[50%] w-full " style={{
                backgroundImage: `url(${imageUrl})`,
            }}>

            </div>
            <div className="w-full pl-4 ">
                <h1 className="text-2xl font-bold font-Montserrat">{title}
                <span className="text-xl font-semibold"> by {userName}</span>
                </h1>
                <p className="text-sm">{content.length > 250 ? `${content.substring(0, 250)}...` : content}</p>

                <p className="text-sm text-right mt-12 mx-4">{formattedDate}</p>
            </div>


        </div>
    );
};

export default PostCard2;

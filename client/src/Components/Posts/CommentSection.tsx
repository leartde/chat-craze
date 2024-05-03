import React, {useEffect, useState} from 'react';
import FetchComments from "@/Services/CommentServices/FetchComments.ts";
import PostComment from "@/Services/CommentServices/PostComment.ts";
import {useSelector} from "react-redux";
import {RootState} from "@/State/Store.ts";
export type Comment = {
    id: number;
    userId: string;
    content: string;
    username: string;
    postId: number;
    postTitle: string;
    userAvatar: string;
}

type CommentSectionProps = {
    postId: number;
}

const CommentSection = ({postId} : CommentSectionProps) => {
    const userClaimsState = useSelector((state: RootState) => state.userClaims);
    const [comments, setComments] = useState<Comment[]>([]);
    const [content, setContent] = useState("");
    const [index, setIndex] = useState(0);

    useEffect(() => {
        const getComments = async () => {
            const comments = await FetchComments(postId);
            setComments(comments);
        }
        getComments();
    },[index, postId]);

    const handleContentChange = (e) => {
        setContent(e.target.value);
    }

    const handleSubmit =async (e) => {
        e.preventDefault();
        await PostComment({postId: postId, content: content, userId: userClaimsState.id});
        setContent("");
        setIndex(index + 1);

    }
    return (
        <div className="w-full ml-12 rounded-xl lg:w-3/4 p-6 text-secondary  border-2 border-secondary bg-primary">
            <h1 className="text-2xl font-bold "> {comments.length} Comments</h1>
            {
                comments.map((comment) => (
                    <div className="flex flex-col gap-4 mt-4 border-primary border-2">
                        <div className="flex gap-4">
                            <img className="h-16 w-16 rounded-xl" src={comment.userAvatar}/>
                            <div>
                                <h1 className="text-lg font-semibold">{comment.username}</h1>
                                <p className="text-sm">{comment.content}</p>
                            </div>
                        </div>

                        {/*<div className="flex flex-col gap-4  border-primary border-2">*/}
                        {/*    <div className="flex gap-4 ml-12 ">*/}
                        {/*        <img className="h-12 w-12 rounded-xl" src={"https://fastly.picsum.photos/id/852/200/200.jpg?hmac=4UHLpiS9j3YDnvq-w-MqnP5-ymiyvMs6BNV5ukoTRrI"}/>*/}
                        {/*        <div>*/}
                        {/*            <h1 className="text-lg font-semibold">Username</h1>*/}
                        {/*            <p className="text-sm">Reply</p>*/}
                        {/*        </div>*/}
                        {/*    </div>*/}

                        {/*</div>*/}

                    </div>

                ))
            }


            <div className="flex flex-col gap-4 mt-4 border-primary border-2">
                <div className="flex gap-4">
                    <img src={userClaimsState.avatarUrl} className="h-16 w-16 rounded-xl"/>
                    <div className="w-full ">
                        <form onSubmit={handleSubmit} className="flex flex-col gap-4">
                            <textarea onChange={handleContentChange} value={content} placeholder="Post a comment..."
                                      className="p-4 w-full h-32 bg-primary text-secondary border-2 border-secondary rounded-xl"></textarea>
                            <button className="bg-secondary h-12 w-32 text-primary rounded-xl">Submit</button>
                        </form>
                    </div>
                </div>
            </div>


        </div>
    );
};

export default CommentSection;

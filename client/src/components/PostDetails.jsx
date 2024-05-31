import { useState, useEffect } from "react";

import { useNavigate, useParams } from "react-router-dom";
import { getPostById } from "../managers/postManager";
import { subscribeToUser } from "../managers/subscriptionManager";



export default function PostDetails({loggedInUser}) {
    const [post, setPost] = useState({});
    const { postId } = useParams();
    const navigate = useNavigate();

    const getAndResetPost = () => {
        getPostById(postId).then(setPost);
    };

    useEffect(() => {
        getAndResetPost();
    }, []);

    const handleSubscribeClick = () => {
        const newSubscription = 
        {
            subscriberId: loggedInUser.id,
            followerId: post.author.id
        }
        subscribeToUser(newSubscription)
    }


    return (
        <>
            <h2>{post.title}</h2>

            <div
                key={post.id}
                className=""
            >
               <img>{post.imageURL}</img>
                <p>{post.content}</p> 
                <p>{post.publicationDate}</p>
                <p>Author: {post.author?.firstName}</p>

            </div>
            <div>
            <button>Subscribe</button>
            </div>

        </>
    );
}
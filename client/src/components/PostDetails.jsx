import { useState, useEffect } from "react";

import { useParams } from "react-router-dom";
import { getPostById } from "../managers/postManager";



export default function PostDetails() {
    const [post, setPost] = useState({});
    const { postId } = useParams();

    const getAndResetPost = () => {
        getPostById(postId).then(setPost);
    };

    useEffect(() => {
        getAndResetPost();
    }, []);

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
                <p>{post.author?.firstName}</p>

            </div>

        </>
    );
}
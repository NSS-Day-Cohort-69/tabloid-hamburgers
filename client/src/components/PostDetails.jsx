import { useState, useEffect, useContext } from "react";
import { useParams } from "react-router-dom";
import { getPostById } from "../managers/postManager";
import { UserContext } from "../App";


export default function PostDetails()
{
    const [post, setPost] = useState({});
    const { postId } = useParams();
    const user = useContext(UserContext)

    const getAndResetPost = () =>
    {
        getPostById(postId).then(setPost);
    };

    useEffect(() =>
    {
        getAndResetPost();
    }, []);

    const onDeleteClicked = () =>
    {
        if(window.confirm(`Confirm delete for: ${post.title}`))
        {
            debugger
        }
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
                <p>{post.author?.firstName}</p>
                {
                    user.id == post.authorId
                    && <button onClick={onDeleteClicked}>Delete</button>
                }
            </div>

        </>
    );
}
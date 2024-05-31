import { useState, useEffect, useContext } from "react";
import { UserContext } from "../App"
import { useNavigate, useParams } from "react-router-dom";
import { getPostById } from "../managers/postManager";
import { subscribeToUser } from "../managers/subscriptionManager";


export default function PostDetails()
{
    const [post, setPost] = useState({});
    const { postId } = useParams();
    const user = useContext(UserContext)

    const navigate = useNavigate()

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
            deletePost(postId).then(() => navigate("/post"))
        }
    }
    const handleSubscribeClick = () =>
    {
        const newSubscription =
        {
            subscriberId: post.author?.id,
            followerId: user.id
        }

        subscribeToUser(newSubscription).then(() => { window.alert(`You are now subscribed to ${post.author?.firstName}`) })
    }


    return (
        <>
            <h2>{post.title}</h2>

            <div
                key={post.id}
                className=""
            >
                <img src={post.imageURL}></img>
                <p>{post.content}</p>
                <p>{post.publicationDate}</p>
                <p>{post.author?.firstName}</p>
                {
                    user.id == post.authorId
                    && <button onClick={onDeleteClicked}>Delete</button>
                }
            </div>
            <div>
                <button onClick={handleSubscribeClick}>Subscribe To Author</button>
                {
                    post.comments?.map(c =>
                        <div>
                            <p>{c.commenteer.userName}</p>
                            <p>{c.subject}</p>
                            <p>{c.content}</p>
                            <p>Made on: {new Date(c.creationDate).toDateString()}</p>
                        </div>)
                }
            </div>

        </>
    );
}
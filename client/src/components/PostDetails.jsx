import { useState, useEffect, useContext } from "react";
import { UserContext } from "../App"
import { useNavigate, useParams } from "react-router-dom";
import { getPostById } from "../managers/postManager";
import { subscribeToUser } from "../managers/subscriptionManager";



export default function PostDetails() {
    const [post, setPost] = useState({});
    const { postId } = useParams();
    const user = useContext(UserContext)

    const getAndResetPost = () => {
        getPostById(postId).then(setPost);
    };

    useEffect(() => {
        getAndResetPost();
    }, []);

    const handleSubscribeClick = () => {
        const newSubscription = 
        {
            subscriberId: post.author?.id,
            followerId: user.id
        }
       
        subscribeToUser(newSubscription).then(() => {window.alert(`You are now subscribed to ${post.author?.firstName}`)})
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
            <button onClick={handleSubscribeClick}>Subscribe To Author</button>
            </div>

        </>
    );
}
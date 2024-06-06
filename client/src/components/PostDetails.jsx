import { useState, useEffect, useContext } from "react";
import { UserContext } from "../App";
import { Link, useNavigate, useParams } from "react-router-dom";
import { getPostById } from "../managers/postManager";
import
  {
    subscribeToUser,
    unsubscribeToUser,
  } from "../managers/subscriptionManager";
import { deleteCommentById } from "../managers/comment";
import
  {
    GetPostReactionsById,
    getAllReactions,
    postNewPostReaction,
  } from "../managers/reaction";
import "./PostView.css";

export default function PostDetails({ loggedInUser })
{
  const [allReactions, setAllReactions] = useState([]);
  const [allPostReactions, setAllPostReactions] = useState([]);
  const [open, setOpen] = useState(false);
  const [post, setPost] = useState({});
  const { postId } = useParams();
  const user = useContext(UserContext);

  const navigate = useNavigate();

  const getAndResetPost = () =>
  {
    getPostById(postId).then(setPost);
  };

  useEffect(() =>
  {
    GetPostReactionsById(postId).then(setAllPostReactions);
  }, []);

  useEffect(() =>
  {
    getAndResetPost();
  }, []);

  useEffect(() =>
  {
    getAllReactions().then(setAllReactions);
  }, []);

  const onDeleteClicked = () =>
  {
    if(window.confirm(`Confirm delete for: ${post.title}`))
    {
      deletePost(postId).then(() => navigate("/post"));
    }
  };
  const handleSubscribeClick = () =>
  {
    const newSubscription = {
      subscriberId: post.author?.id,
      followerId: user.id,
    };

    subscribeToUser(newSubscription).then(() =>
    {
      window.alert(`You are now subscribed to ${post.author?.firstName}`);
    });
  };

  const handleUnsubscribeClick = () =>
  {
    const followerId = user.id;
    const subscriberId = post.author.id;
    unsubscribeToUser(followerId, subscriberId).then(() =>
    {
      window.alert(`You have unsubscribed from ${post.author?.firstName}`);
    });
  };

  const handleDeleteComment = (CommentId) =>
  {
    deleteCommentById(CommentId).then(() =>
    {
      getPostById(postId).then(setPost);
    });
  };

  return (
    <>
      <h2>{post.title}</h2>

      <div key={post.id} className="">
        {!post.image ? (
          <img
            src={
              "https://resources.alleghenycounty.us/css/images/Default_No_Image_Available.png"
            }
          />
        ) : (
          <img src={`data:image/jpeg;base64,${post.image}`} />
        )}
        <p>{post.content}</p>
        <p>{post.publicationDate}</p>
        <p>{post.author?.firstName}</p>
        {user.id == post.authorId && (
          <button onClick={onDeleteClicked}>Delete</button>
        )}
      </div>
      <div>
        <button
          onClick={() =>
          {
            navigate(`comment`);
          }}
        >
          Add Comment
        </button>
        <button onClick={handleSubscribeClick}>Subscribe To Author</button>
        <button onClick={handleUnsubscribeClick}>
          Unsubscribe From Author
        </button>
        {post.comments?.map((c) => (
          <div key={"c" + c.id}>
            <p>{c.commenteer.userName}</p>{" "}
            {loggedInUser.id === c.commenteerId && (
              <Link to={`/${c.id}/comment-edit`}>Edit!</Link>
            )}
            {(loggedInUser.id === c.commenteerId ||
              loggedInUser.roles.includes("Admin")) && (
                <button
                  onClick={() =>
                  {
                    handleDeleteComment(c.id);
                  }}
                >
                  Delete
                </button>
              )}
            <p>{c.subject}</p>
            <p>{c.content}</p>
            <p>Made on: {new Date(c.creationDate).toDateString()}</p>
          </div>
        ))}
        <button
          onClick={() =>
          {
            setOpen(!open);
          }}
        >
          Add Reaction
        </button>
        <section>
          {open &&
            allReactions.map((r) =>
            {
              return (
                <img
                  onClick={() =>
                  {
                    postNewPostReaction({
                      postId: postId,
                      reactorId: loggedInUser.id,
                      reactionId: r.id,
                    }).then(() =>
                    {
                      GetPostReactionsById(postId).then(setAllPostReactions);
                    });
                  }}
                  className="PostDetails-img"
                  key={r.id}
                  src={r.imageURL}
                />
              );
            })}
        </section>
        {allReactions.map((r) =>
        {
          return (
            <section key={r.id}>
              <img className="PostDetails-img" src={r.imageURL} />{" "}
              {allPostReactions &&
                allPostReactions.filter((pr) => pr.reactionId == r.id).length}
            </section>
          );
        })}
      </div>
    </>
  );
}

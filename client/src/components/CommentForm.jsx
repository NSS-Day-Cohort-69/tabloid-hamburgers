import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { createNewComment } from "../managers/comment";

export const CommentForm = ({ loggedInUser }) => {
  const [commentObject, setCommentObject] = useState({
    subject: "",
    content: "",
  });
  const { postId } = useParams();
  const navigate = useNavigate();

  const handleSave = (e) => {
    e.preventDefault();

    const newComment = {
      Subject: commentObject.subject,
      Content: commentObject.content,
      PostId: parseInt(postId),
      CommenteerId: loggedInUser.id,
    };

    createNewComment(newComment).then(() => {
      navigate(`/post/${postId}`);
    });
  };

  return (
    <main>
      <div>
        <form onSubmit={handleSave}>
          <input
            required
            value={commentObject.subject}
            onChange={(e) => {
              const copy = { ...commentObject };
              copy.subject = e.target.value;
              setCommentObject(copy);
            }}
          />
          <textarea
            required
            value={commentObject.content}
            onChange={(e) => {
              const copy = { ...commentObject };
              copy.content = e.target.value;
              setCommentObject(copy);
            }}
          />
          <button type="submit">Surbmurt</button>
        </form>
      </div>
    </main>
  );
};

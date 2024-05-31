import { useState } from "react";
import { useParams } from "react-router-dom";

export const CommentForm = ({ loggedInUser }) => {
  const [commentObject, setCommentObject] = useState({});
  const { postId } = useParams();

  const handleSave = (e) => {
    e.preventDefault();

    const newComment = {
      Subject: commentObject.subject,
      Content: commentObject.content,
      PostId: parseInt(postId),
      CommenterId: loggedInUser.id,
    };
  };

  return (
    <main>
      <div>
        <form onSubmit={handleSave}>
          <input
            required
            defaultValue={commentObject.subject}
            onChange={(e) => {
              const copy = { ...commentObject };
              copy.subject = e.target.value;
              setCommentObject(copy);
            }}
          />
          <textarea
            required
            defaultValue={commentObject.content}
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

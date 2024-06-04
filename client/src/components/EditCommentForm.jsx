import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
  createNewComment,
  getCommentById,
  updateCommentByBody,
} from "../managers/comment";

export const EditCommentForm = () => {
  const [commentObject, setCommentObject] = useState({});
  const { CommentId } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    getCommentById(CommentId).then(setCommentObject);
  }, []);

  const handleSave = (e) => {
    e.preventDefault();

    updateCommentByBody(commentObject).then(() => {
      navigate(`/post/${commentObject.postId}`);
    });
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
          <button type="submit">Soobment</button>
        </form>
      </div>
    </main>
  );
};

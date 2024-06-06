const _apiUrl = "/api/comment";

export const createNewComment = (commentObject) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(commentObject),
  });
};

export const getCommentById = (CommentId) => {
  return fetch(`${_apiUrl}/${CommentId}`).then((res) => res.json());
};

export const updateCommentByBody = (CommentObj) => {
  return fetch(`${_apiUrl}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(CommentObj),
  });
};

export const deleteCommentById = (CommentId) => {
  return fetch(`${_apiUrl}/${CommentId}`, { method: "DELETE" });
};

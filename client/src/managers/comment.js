const _apiUrl = "/api/comment";

export const createNewComment = (commentObject) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(commentObject),
  });
};

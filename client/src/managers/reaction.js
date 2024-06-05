const _apiUrl = "/api/reaction";

export const createNewReaction = (ReactionObject) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(ReactionObject),
  });
};

export const getAllReactions = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const postNewPostReaction = (postReactionObj) => {
  return fetch(`${_apiUrl}/postreaction`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(postReactionObj),
  });
};

export const GetPostReactionsById = (PostId) => {
  return fetch(`${_apiUrl}/${PostId}/postreaction`).then((res) => res.json());
};

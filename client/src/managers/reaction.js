const _apiUrl = "/api/reaction";

export const createNewReaction = (ReactionObject) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(ReactionObject),
  });
};

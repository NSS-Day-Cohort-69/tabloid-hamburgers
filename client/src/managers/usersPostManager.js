const _apiUrl = "/api/userspost";

export const getPostByAuthorId = (authorId) => {
    return fetch(`${_apiUrl}/${authorId}`).then((res) => res.json());
}
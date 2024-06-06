export const getPosts = () =>
{
    return fetch('/api/post').then(res => res.json())
}

export const getPublicPosts = () =>
{
    return fetch('/api/post/public').then(res => res.json())
}

export const createPostByMe = (post) =>
{
    return fetch('/api/post/by-me',
        {
            method: "POST",
            body: post
        })
}

export const getPostById = (id) =>
{
    return fetch(`/api/post/${id}`).then((res) => res.json());
};

export const editPost = (post, id) =>
{
    return fetch(`/api/post/${id}`,
        {
            method: "PUT",
            body: post
        })
}

export const deletePost = (id) =>
{
    return fetch(`/api/post/${id}`,
        { method: "DELETE" })
}

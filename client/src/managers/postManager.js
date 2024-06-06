export const getPosts = () =>
{
    return fetch('/api/post').then(res => res.json())
}

export const getPostsByUser = (userId) =>
{
    return fetch(`/api/post/user/${userId}`).then(res => res.json())
}

export const getPublicPosts = () =>
{
    return fetch('/api/post/public').then(res => res.json())
}

export const getUnapprovedPosts = () =>
{
    return fetch('/api/post/unapproved').then(res => res.json())
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

export const unapprovePost = (id) =>
{
    return fetch(`/api/post/unapprove/${id}`,
        {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(id)
        })
}

export const approvePost = (id) =>
{
    return fetch(`/api/post/approve/${id}`,
        {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(id)
        })
}

export const getSubscribedPosts = () =>
{
    return fetch(`/api/post/subscribed`).then(res => res.json())
}
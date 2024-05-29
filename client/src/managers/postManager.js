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
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(post)
        }).then(res => res.json())
}
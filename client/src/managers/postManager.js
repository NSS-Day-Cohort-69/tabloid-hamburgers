export const getPosts = () =>
{
    return fetch('/api/post').then(res => res.json())
}

export const getPublicPosts = () =>
{
    return fetch('/api/post/public').then(res => res.json())
}
export const getPosts = () =>
{
    return fetch('/api/post').then(res => res.json())
}
export const getPosts = () =>
{
    return fetch('/api/post').then(res => res.json())
}

export const getPublicPosts = () =>
{
    return fetch('/api/post/public').then(res => res.json())
}


export const getPostById = (id) => {
    return fetch(`/api/post/${id}`).then((res) => res.json());
  };
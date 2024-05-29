import { Fragment, useEffect, useState } from "react"
import { getPublicPosts } from "../managers/postManager"

const PostList = () =>
{
    const [posts, setPosts] = useState([])

    useEffect(
        () =>
        {
            getPublicPosts().then(
                (posts) =>
                {
                    setPosts(
                        posts.sort((a, b) => new Date(b.publication) - new Date(a.publication)))
                }
            )
        }, []
    )

    return <>
        {
            posts.map(p =>
                <div key={"p" + p.id}>
                    <div>{p.title}</div>
                    <div>{p.author.fullName}</div>
                    <div>{p.category.categoryName}</div>
                    <br/>
                </div>)
        }
    </>
}

export default PostList
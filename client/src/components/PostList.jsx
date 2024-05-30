import { Fragment, useContext, useEffect, useState } from "react"
import { getPublicPosts } from "../managers/postManager"
import { Link } from "react-router-dom"
import { UserContext } from "../App"

const PostList = () =>
{
    const user = useContext(UserContext)
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
                    <Link to={`/post/${p.id}`}><div>{p.title}</div></Link>

                    <div>{p.author.fullName}</div>
                    <div>{p.category.categoryName}</div>
                    {
                        p.authorId == user.id && <Link to={`/post/${p.id}/edit`}>edit</Link>
                    }
                    <br />
                </div>)
        }
    </>
}

export default PostList
import { useEffect, useState } from "react";
import "./PostView.css";
import { approvePost, getSubscribedPosts, getUnapprovedPosts } from "../managers/postManager";
import { Link } from "react-router-dom";

const Home = () =>
{

    const [subscribedPosts, setSubscribedPosts] = useState([]);

    const getAndSetUnapprovedPosts = () =>
    {
        getSubscribedPosts().then(setSubscribedPosts)
    }

    useEffect(() =>
    {
        getAndSetUnapprovedPosts();
    }, []);

    const handleApproveClick = (event) =>
    {
        approvePost(event.target.value).then(getAndSetUnapprovedPosts)
    }

    return (
        <main>
            <div className="PostList-div-maincontainer">
                <section className="PostList-section-posts">
                    {subscribedPosts.map((p) => (
                        <article key={"p" + p.id} className="PostList-post-border">

                            <header className="PostList-post-header">
                                {p.publication}{" "}
                                {p.readTime > 1
                                    ? `${p.readTime} Minutes`
                                    : `${p.readTime} Minute`}
                            </header>
                            {p.imageURL == null || "" ? (
                                <img
                                    src={
                                        "https://resources.alleghenycounty.us/css/images/Default_No_Image_Available.png"
                                    }
                                />
                            ) : (
                                <img src={p.imageURL} />
                            )}

                            <div>
                                <Link to={`/post/${p.id}`} className="PostList-linkto-post">
                                    <div>{p.title}</div>
                                </Link>
                                <div>{p.author.fullName}</div>
                                <div>{p.category.categoryName}</div>
                                <div><p>{p.content}</p></div>
                            </div>

                        </article>

                    ))}
                </section>
            </div>
        </main>
    );
};

export default Home

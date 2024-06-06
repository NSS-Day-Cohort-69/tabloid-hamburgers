import { useEffect, useState } from "react";
import "./PostView.css";
import { approvePost, getUnapprovedPosts } from "../managers/postManager";

const UnapprovedPosts = () => {
   

    const [unapprovedPosts, setUnapprovedPosts] = useState([]);

    const getAndSetUnapprovedPosts = () => {
        getUnapprovedPosts().then(setUnapprovedPosts)
    }

    useEffect(() => {
        getAndSetUnapprovedPosts();
    }, []);

    const handleApproveClick = (event) => {
        approvePost(event.target.value).then(getAndSetUnapprovedPosts())
    }

    return (
        <main>
            <div className="PostList-div-maincontainer">
                <section className="PostList-section-posts">
                    {unapprovedPosts.map((p) => (
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
                                <div>{p.title}</div>
                                <div>{p.author.fullName}</div>
                                <div>{p.category.categoryName}</div>
                                <div><p>{p.content}</p></div>
                                <button value={p.id} onClick={handleApproveClick}>Approve</button>
                            </div>
                           
                        </article>
                        
                    ))}
                </section>
            </div>
        </main>
    );
};

export default UnapprovedPosts;

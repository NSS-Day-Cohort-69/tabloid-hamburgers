import { useEffect, useState } from "react";
import { deleteTagById, getAllTags } from "../../managers/tags";

export const TagsView = () => {
  const [allTags, setAllTags] = useState([]);

  const getTagsData = () => {
    getAllTags().then(setAllTags);
  };

  useEffect(() => {
    getTagsData();
  }, []);

  return (
    <main>
      <div>
        {allTags.map((t) => {
          return (
            <article key={t.id}>
              {t.tagName}{" "}
              <button
                onClick={() => {
                  if (window.confirm(`Confirm delete for: ${t.tagName}`)) {
                    deleteTagById(t.id).then(() => {
                      getTagsData();
                    });
                  }
                }}
              >
                Delete
              </button>
            </article>
          );
        })}
      </div>
    </main>
  );
};

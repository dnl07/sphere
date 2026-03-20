type Props = {
    children: React.ReactNode;
    title?: string
}

const PageWrapper = ({ children, title }: Props) => {
    return(
        <div title={title} className="flex-1 flex flex-col w-full items-center  max-w-6xl mx-auto px-2">
            {children}
        </div>
    );
}

export default PageWrapper;